const sectionElement = document.getElementById('notifications');

const errorDiv = document.getElementById('errorNotification');
const successDiv = document.getElementById('successNotification');
const loadDiv = document.getElementById('loadingNotification');

export default {
    success(message) {
        successDiv.textContent = message;
        sectionElement.style.display = 'block';

        sectionElement.addEventListener('click', () => sectionElement.style.display = 'none');
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