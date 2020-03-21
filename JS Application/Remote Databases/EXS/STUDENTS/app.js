import { requests } from './firebaseRequests.js';

(() => {
    const loadButton = document.getElementById('loadBtn');
    const addButton = document.getElementById('addBtn');
    const createStudentForm = document.getElementById('createStudent');
    const message = document.getElementById('message');
    const tbody = document.querySelector('tbody');

    loadButton.addEventListener('click', loadStudents);

    addButton.addEventListener('click', (e) => {
        e.preventDefault();
        addStudent();
    });

    function addStudent() {
        let studentInfo = extractStudentInfo(createStudentForm);

        if (Object.keys(studentInfo).length !== 5) {
            message.textContent = 'Please make sure that all fields are completed.';
        }
        else {
            clearFormInputs(createStudentForm);
            requests.postStudent(studentInfo);
        }
    }

    function loadStudents() {
        tbody.innerHTML = '';
        clearFormInputs(createStudentForm);

        requests.getStudents().then((students) => {
            if (students !== null && students !== undefined) {
                Object.entries(students)
                    .sort((a, b) => a[1].studentId - b[1].studentId)
                    .map(s => s[1])
                    .forEach(studentInfo => {
                        let studentRow = getStudentRow(studentInfo);
                        tbody.appendChild(studentRow);
                    });
            }
        });
    }

    function getStudentRow(studentInfo) {
        let row = document.createElement('tr');

        let id = document.createElement('td');
        id.textContent = studentInfo.studentId;
        row.appendChild(id);

        let firstName = document.createElement('td');
        firstName.textContent = studentInfo.firstName;
        row.appendChild(firstName);

        let lastName = document.createElement('td');
        lastName.textContent = studentInfo.lastName;
        row.appendChild(lastName);

        let facultyNumber = document.createElement('td');
        facultyNumber.textContent = studentInfo.facultyNumber;
        row.appendChild(facultyNumber);

        let grade = document.createElement('td');
        grade.textContent = `${Number(studentInfo.grade).toFixed(2)}`;
        row.appendChild(grade);
        return row;
    }

    function extractStudentInfo(form) {
        let student = {};

        Array.from(form.children)
            .filter(x => x.tagName === 'INPUT')
            .forEach(i => {
                let inputId = i.getAttribute('id')

                if (i.value !== '') {
                    student[inputId] = i.value;
                }
            });

        return student;
    }

    function clearFormInputs(form) {
        message.textContent = '';

        Array.from(form.children)
            .filter(x => x.tagName === 'INPUT')
            .map(x => x.value = '');
    }
})();