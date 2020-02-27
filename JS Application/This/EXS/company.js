class Company {
    constructor() {
        this.departments = [];
    }

    addEmployee(username, salary, position, department) {
        if (!username || !salary || !position || !department || Number(salary) < 0) {
            throw new Error("Invalid input!");
        }

        if (!this.departments.some(d => d.name === department)) {
            this.departments.push({ name: department, employees: [] });
        }

        this.departments.find(d => d.name === department).employees.push({ username, salary, position });
        return `New employee is hired. Name: ${username}. Position: ${position}`;
    }

    bestDepartment() {
        let best = this.departments.sort((a, b) => this.getAvgSalary(b) - this.getAvgSalary(a))[0];

        let result = `Best Department is: ${best.name}\n`;
        result += `Average salary: ${this.getAvgSalary(best).toFixed(2)}\n`;

        best.employees
            .sort((a, b) => a.salary === b.salary ? a.username.localeCompare(b.username) : b.salary - a.salary)
            .forEach(e => {
                result += `${e.username} ${e.salary} ${e.position}\n`
            });

        return result.trim();
    }

    getAvgSalary(department) {
        return department.employees.reduce((acc, curr) => acc + curr.salary, 0) / department.employees.length;
    }
}