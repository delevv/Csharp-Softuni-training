function attachEventsListeners() {
    let buttons = document.querySelectorAll("input[type='button']");
    let inputs = document.querySelectorAll("input[type='text']");

    Array.from(buttons).forEach(b => {
        b.addEventListener('click', function (e) {
            let totalSeconds = getTotalSeconds(e.target)

            for (const input of Array.from(inputs)) {
                let inputId = input.id;

                switch (inputId) {
                    case 'days': input.value = totalSeconds / 60 / 60 / 24;
                        break;
                    case 'hours': input.value = totalSeconds / 60 / 60;
                        break;
                    case 'minutes': input.value = totalSeconds / 60;
                        break;
                    case 'seconds': input.value = totalSeconds;
                        break;
                }
            }

        });
    });

    function getTotalSeconds(button) {
        let buttonId = button.id;
        let inputValue = button.previousElementSibling.value;

        switch (buttonId) {
            case 'daysBtn': return +inputValue * 24 * 60 * 60;
            case 'hoursBtn': return +inputValue * 60 * 60;
            case 'minutesBtn': return +inputValue * 60;
            case 'secondsBtn': return +inputValue;
        }
    }
}