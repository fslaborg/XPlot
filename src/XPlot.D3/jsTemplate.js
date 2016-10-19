// set a width and height for our SVG
        var width = {WIDTH},
            height = {HEIGHT};
        
        var nodes = {NODES};

        var links = {LINKS}
        
        var svg = d3.select('#{GUID}').append('svg')
            .attr('width', width)
            .attr('height', height);

        var linkStyles = {LINKSTYLES}

        var link = svg.selectAll('.link')
            .data(links)
            .enter().append('line')
            .style('stroke',function(d,i) { return linkStyles[i]['StrokeHex']; })
            .style('stroke-width', function(d,i) { return linkStyles[i]['StrokeWidth']; })
            .attr('class', 'link');

        var nodeStyles = {NODESTYLES}

        var radius = width / (nodes.length * 7);

        var node = svg.selectAll('.node')
            .data(nodes)
            .enter().append('circle')
            .attr('class', 'node')
            .style('stroke',function(d,i) { return nodeStyles[i]['StrokeHex']; })
            .style('stroke-width',function(d,i) { return nodeStyles[i]['StrokeWidth']; })
            .style('fill',function(d,i) { return nodeStyles[i]['FillHex']; })
            .attr('cx', function(d,i) { return width/2; }) 
            .attr('cy', function(d,i) { return height/2; })
            .attr('r', function(d,i) { return nodeStyles[i]['RadiusScale'] * radius; }); 

        function tick(e) {
                node.attr('r', function(d,i) { return nodeStyles[i]['RadiusScale'] * radius; })
                    .attr('cx', function(d) { return d.x; })
                    .attr('cy', function(d) { return d.y; })
                    .call(force.drag) 
                    ;
            
                link.attr('x1', function(d) { return d.source.x; })
                    .attr('y1', function(d) { return d.source.y; })
                    .attr('x2', function(d) { return d.target.x; })
                    .attr('y2', function(d) { return d.target.y; });
            }


        var force = d3.layout.force()
            .size([width, height])
            .nodes(nodes)
            .links(links)
            .gravity({GRAVITY})
            .on("tick", tick)
            .linkDistance( function (d,i) {
                return linkStyles[i]['Distance'];
            })
            .linkStrength(1)
            .charge({CHARGE})
            .start();