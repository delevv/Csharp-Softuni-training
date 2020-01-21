function solve(input) {  
    let regex = /\s*\|\s*/;
    let towns = [];
 
    for(let line of input.splice(1)) {
        let lineInfo = line.split(regex);
        let obj = { 
            Town: lineInfo[1], 
            Latitude: +(+(lineInfo[2])).toFixed(2), 
            Longitude: +(+(lineInfo[3])).toFixed(2)
        };
        towns.push(obj);
    }

    console.log(JSON.stringify(towns));
}

solve(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']
);