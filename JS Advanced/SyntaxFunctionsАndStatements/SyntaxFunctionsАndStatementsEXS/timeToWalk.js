function solve(stepsCount, footLength, speedInKm) {

    let totalLength = stepsCount * footLength;
    let countOfBreaks = Math.floor(totalLength / 500);
    let totalTime = (totalLength / speedInKm / 1000 * 60) + countOfBreaks;

    var time = new Date(null, null, null, null, null, Math.ceil(totalTime * 60));
    var timeToFormat = time.toString().split(' ')[4];

    console.log(timeToFormat);
}

solve(4000, 0.60, 5);