function encodeAndDecodeMessages() {
    let buttons = document.getElementsByTagName('button');
    let encodeButton = buttons[0];
    let decodeButton = buttons[1];

    encodeButton.addEventListener('click', () => {
        // let input = encodeButton.previousElementSibling;
        let input = document.getElementsByTagName('textarea')[0];
        // let output = decodeButton.previousElementSibling;
        let output = document.getElementsByTagName('textarea')[1];

        output.value = encodeAndDecode(input.value, 1);
        input.value = '';
    });

    decodeButton.addEventListener('click', () => {
        // let input = decodeButton.previousElementSibling;
        let input = document.getElementsByTagName('textarea')[1];
        input.value = encodeAndDecode(input.value, -1);
    });

    function encodeAndDecode(text, code) {
        let codeMessage = '';
        Array.from(text).forEach(ch => {
            codeMessage += String.fromCharCode(ch.charCodeAt(0) + code);
        });
        return codeMessage;
    }
}