function attachEvents() {
    let locationInput = document.getElementById('location');
    let button = document.getElementById('submit');
    let currentConditions = document.getElementById('current');
    let upcomingConditions = document.getElementById('upcoming');
    let forecast = document.getElementById('forecast');

    weatherSymbols = {
        Sunny: '☀',
        'Partly sunny': '⛅',
        Overcast: '☁',
        Rain: '☂',
        Degrees: '°'
    }

    button.addEventListener('click', showFullWeather);

    function showFullWeather() {
        clearPreviousRequest();
        forecast.style.display = 'block';

        fetch('https://judgetests.firebaseio.com/locations.json')
            .then((r) => r.json())
            .then((data) => {
                let currentLocation = data.find(d => d.name === locationInput.value);

                showTodayWeather(currentLocation);
                showUpcomingWeather(currentLocation);
            })
            .catch(() => {
                let div = document.createElement('div');
                div.id = 'message';
                div.textContent = 'Error';
                forecast.appendChild(div);
            });
    }

    function showTodayWeather(currentLocation) {
        fetch(`https://judgetests.firebaseio.com/forecast/today/${currentLocation.code}.json`)
            .then((r) => r.json())
            .then((currentWeather) => {
                let div = document.createElement('div');
                div.classList.add('forecasts');

                let condSymbolSpan = document.createElement('span');
                condSymbolSpan.classList.add('condition');
                condSymbolSpan.classList.add('symbol');
                condSymbolSpan.textContent = weatherSymbols[currentWeather.forecast.condition];

                let conditionSpan = document.createElement('span');
                conditionSpan.classList.add('condition');
                conditionSpan.innerHTML = `<span class=forecast-data>${currentWeather.name}</span>` +
                    `<span class=forecast-data>${formatTemperatures(currentWeather.forecast.low, currentWeather.forecast.high)}</span>` +
                    `<span class=forecast-data>${currentWeather.forecast.condition}</span>`;

                div.appendChild(condSymbolSpan);
                div.appendChild(conditionSpan);

                currentConditions.appendChild(div);
            });
    }

    function showUpcomingWeather(currentLocation) {
        fetch(`https://judgetests.firebaseio.com/forecast/upcoming/${currentLocation.code}.json`)
            .then((r) => r.json())
            .then((nextDaysWeather) => {
                let div = document.createElement('div');
                div.classList.add('forecast-info');

                nextDaysWeather.forecast.forEach((day) => {
                    let span = document.createElement('span');
                    span.classList.add('upcoming');

                    span.innerHTML += `<span class=symbol>${weatherSymbols[day.condition]}</span>` +
                        `<span class=forecast-data>${formatTemperatures(day.low, day.high)}</span>` +
                        `<span class=forecast-data>${day.condition}</span>`;

                    div.appendChild(span);
                });

                upcomingConditions.appendChild(div);
            });
    }

    function formatTemperatures(low, high) {
        return `${low}${weatherSymbols.Degrees}/${high}${weatherSymbols.Degrees}`;
    }

    function clearPreviousRequest() {
        if (currentConditions.children.length > 1) {
            currentConditions.children[1].remove();
            upcomingConditions.children[1].remove();
        }
        if (forecast.children.length > 2) {
            forecast.children[2].remove();
        }
    }
}

attachEvents();