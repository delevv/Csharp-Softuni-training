function solve() {
    let id = 0;
    let reports = [];

    let bugTracker = {
        selector: '',
        report: function (author, description, reproducible, severity) {
            reports.push({
                ID: id++,
                author,
                description,
                reproducible,
                severity,
                status: 'Open'
            });
            this.print();
        },
        setStatus: function (id, newStatus) {
            let curr = reports.find(r => r.ID === id);
            curr.status = newStatus;
            this.print();
        },
        remove: function (id) {
            reports = reports.filter(r => r.ID != id);
            this.print();
        },
        sort: function (method) {
            switch (method) {
                case 'author': reports.sort((a, b) => a.author.localeCompare(b.author));
                    break;
                case 'severity': reports.sort((a, b) => a.severity - b.severity);
                    break;
                default: reports.sort((a, b) => a.ID - b.ID);
                    break;
            }
            this.print();
        },
        output: function (selector) {
            this.selector = selector;
            this.print();
        },
        print: function () {
            let selector = document.querySelector(this.selector);
            selector.innerHTML = '';

            reports.forEach(r => {
                selector.innerHTML += `<div id="report_${r.ID}" class="report">` +
                    '<div class="body">' +
                    `<p>${r.description}</p>` +
                    '</div>' +
                    '<div class="title">' +
                    `<span class="author">Submitted by: ${r.author}</span>` +
                    `<span class="status">${r.status} | ${r.severity}</span>` +
                    '</div>' +
                    '</div>';
            });
        }
    }

    return bugTracker;
}