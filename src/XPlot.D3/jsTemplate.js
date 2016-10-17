// set a width and height for our SVG
        var width = {WIDTH},
            height = {HEIGHT};
        
        // Define the nodes to be drawn
        var nodes = {NODES};

        var links = {EDGES}
        
        // Add a SVG to the body for our graph
        var svg = d3.select('#{GUID}').append('svg')
            .attr('width', width)
            .attr('height', height);

        var link = svg.selectAll('.link')
            .data(links)
            .enter().append('line')
            .style('stroke','black')
            .style('stroke-width', '1px')
            .attr('class', 'link');

        var nodeStyles = {NODESTYLES}

        var radius = width / (nodes.length * 7);

        // Now it's the nodes turn. Each node is drawn as a circle.
        var node = svg.selectAll('.node')
            .data(nodes)
            .enter().append('circle')
            .attr('class', 'node')
            .style('stroke',function(d,i) { return nodeStyles[i]['StrokeHex']; })
            .style('stroke-width',function(d,i) { return nodeStyles[i]['StrokeWidth']; })
            .style('fill',function(d,i) { return nodeStyles[i]['FillHex']; })
            .attr('cx', function(d,i) { return (i+1)*(width/4); }) //relative position
            .attr('cy', function(d,i) { return height/2; }) //relative position
            .attr('r', function(d,i) { return nodeStyles[i]['RadiusScale'] * radius; }); 

        function tick(e) {
                node.attr('r', function(d,i) { return nodeStyles[i]['RadiusScale'] * radius; })
                    .attr('cx', function(d) { return d.x; })
                    .attr('cy', function(d) { return d.y; })
                    .call(force.drag) //let them be dragged around
                    ;
            
                link.attr('x1', function(d) { return d.source.x; })
                    .attr('y1', function(d) { return d.source.y; })
                    .attr('x2', function(d) { return d.target.x; })
                    .attr('y2', function(d) { return d.target.y; });
            }


        // create the force layout graph
        var force = d3.layout.force()
            .size([width, height])
            .nodes(nodes)
            .links(links)
            .gravity({GRAVITY})
            .on("tick", tick)
            .linkDistance(width/2) 
        .start();