function attachEventsListeners() {
    let inputOption = document.getElementById('inputUnits');
    let outputOption = document.getElementById('outputUnits');

    let input = document.getElementById('inputDistance');
    let output = document.getElementById('outputDistance');

    document.getElementById('convert').addEventListener('click', () => {
        let totalMeters = getTotalMeters(input.value, inputOption.value);
        let currentDistance = convertDistance(totalMeters, outputOption.value);
        output.value = currentDistance;
    })

    function getTotalMeters(value, type) {
        switch (type) {
            case 'km': return +value * 1000;
            case 'm': return +value;
            case 'cm': return +value * 0.01;
            case 'mm': return +value * 0.001;
            case 'mi': return +value * 1609.34;
            case 'yrd': return +value * 0.9144;
            case 'ft': return +value * 0.3048;
            case 'in': return +value * 0.0254;
        }
    }
    function convertDistance(totalMeters, type) {
        switch (type) {
            case 'km': return totalMeters / 1000;
            case 'm': return totalMeters;
            case 'cm': return totalMeters / 0.01;
            case 'mm': return totalMeters / 0.001;
            case 'mi': return totalMeters / 1609.34;
            case 'yrd': return totalMeters / 0.9144;
            case 'ft': return totalMeters / 0.3048;
            case 'in': return totalMeters / 0.0254;
        }
    }
}