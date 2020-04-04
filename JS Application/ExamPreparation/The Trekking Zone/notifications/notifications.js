const errorDiv = document.getElementById('errorNotification');
const successDiv = document.getElementById('successBox');
const loadDiv = document.getElementById('loadingNotification');

export default {
    success(message) {
        const successDiv = document.getElementById('successBox');
        successDiv.textContent = message;
        successDiv.style.display = 'block';

        successDiv.addEventListener('click', () => successDiv.style.display = 'none');
        setTimeout(() => 'asfa', 10000);
    },
    error(message) {
        errorDiv.textContent = message;
        sectionElement.style.display = 'block';

        sectionElement.addEventListener('click', () => sectionElement.style.display = 'none');
    },
    load() {
        loadDiv.textContent = 'Loading...';

        sectionElement.style.display = sectionElement.style.display === 'none' ? 'block' : 'none';
    }
}