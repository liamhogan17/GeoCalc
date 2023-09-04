import React, { useState, useRef, useEffect } from 'react';
import * as d3 from 'd3';

function Graphing() {

    const [data] = useState([25, 47, 2, 15, 60, 56, 43, 25, 32, 12]);
    const svgRef = useRef();
    useEffect(() => {

        // set up svg

        const w = 1300;
        const h = 500;
        const svg = d3.select(svgRef.current)
            .attr('width', w)
            .attr('height', h)
            .style('margin-top', '100')
            .style('overflow', 'visible')

        // set up scaling

        const xScale = d3.scaleLinear()
            .domain([0, data.length - 1])
            .range([0, w]);

        const yScale = d3.scaleLinear()
            .domain([0, h])
            .range([h, 0]);

        const generateScaledLine = d3.line()
            .x((d, i) => xScale(i))
            .y(yScale)
            .curve(d3.curveCardinal);

        // set axes

        const xAxis = d3.axisBottom(xScale)
            .ticks(data.length)
            .tickFormat(i => i + 1);

        const yAxis = d3.axisLeft(yScale)
            .ticks(5);

        svg.append('g')
            .call(xAxis)
            .attr('transform', `translate(0, ${h})`);

        svg.append('g')
            .call(yAxis);

        // set up data for svg

        svg.selectAll('.line')
            .data([data])
            .join('path')
            .attr('d', d => generateScaledLine(d))
            .attr('fill', 'none')
            .attr('stroke', 'black');

    }, [data]);

    return (
        <div class='card'>
            <svg ref = {svgRef}></svg>
        </div>
    )
}
export default Graphing;