class Organization {
    constructor(name, budget) {
        this.name = name;
        this.budget = budget;
        this.employees = [];
        this.marketing = +this.budget * 0.40;
        this.finance = +this.budget * 0.25;
        this.production = +this.budget * 0.35;
    }

    get departmentsBudget() {
        return {
            marketing: this.marketing,
            finance: this.finance,
            production: this.production
        };
    }

    add(employeeName, department, salary) {
        let message = '';

        if (+this.departmentsBudget[department] >= +salary) {
            this.employees.push({ employeeName, department, salary });

            switch (department) {
                case "marketing": this.marketing -= +salary; break;
                case "finance": this.finance -= +salary; break;
                case "production": this.production -= +salary; break;
            }

            message = `Welcome to the ${department} team Mr./Mrs. ${employeeName}.`;
        }
        else {
            message = `The salary that ${department} department can offer to you Mr./Mrs. ${employeeName} is $${this.departmentsBudget[department]}.`
        }

        return message;
    }

    employeeExists(employeeName) {
        let message = '';
        let employee = this.employees.find(e => e.employeeName === employeeName);

        if (employee) {
            message = `Mr./Mrs. ${employee.employeeName} is part of the ${employee.department} department.`;
        }
        else {
            message = `Mr./Mrs. ${employeeName} is not working in ${this.name}.`;
        }

        return message;
    }

    leaveOrganization(employeeName) {
        let message = '';
        let employee = this.employees.find(e => e.employeeName === employeeName);

        if (employee) {
            switch (employee.department) {
                case "marketing": this.marketing += employee.salary; break;
                case "finance": this.finance += employee.salary; break;
                case "production": this.production += employee.salary; break;
            }

            let index = this.employees.indexOf(employee);
            this.employees.splice(index, 1);

            message = `It was pleasure for ${this.name} to work with Mr./Mrs. ${employeeName}.`;
        }
        else {
            message = `Mr./Mrs. ${employeeName} is not working in ${this.name}.`;
        }

        return message;
    }

    status() {
        let marketingEmployees = this.employees.filter(e => e.department === 'marketing');
        let financeEmployees = this.employees.filter(e => e.department === 'finance');
        let productionEmployees = this.employees.filter(e => e.department === 'production');

        let sortedMarketingEmployees = marketingEmployees.sort((a, b) => b.salary - a.salary);
        let sortedFinanceEmployees = financeEmployees.sort((a, b) => b.salary - a.salary);
        let sortedProductionEmployees = productionEmployees.sort((a, b) => b.salary - a.salary);

        let output = '';
        output += `${this.name.toUpperCase()} DEPARTMENTS:`;
        output += `\nMarketing | Employees: ${sortedMarketingEmployees.length}: ${sortedMarketingEmployees.map(e => e.employeeName).join(', ')} | Remaining Budget: ${this.departmentsBudget['marketing']}`;
        output += `\nFinance | Employees: ${sortedFinanceEmployees.length}: ${sortedFinanceEmployees.map(e => e.employeeName).join(', ')} | Remaining Budget: ${this.departmentsBudget['finance']}`;
        output += `\nProduction | Employees: ${sortedProductionEmployees.length}: ${sortedProductionEmployees.map(e => e.employeeName).join(', ')} | Remaining Budget: ${this.departmentsBudget['production']}`;

        return output;
    }
}