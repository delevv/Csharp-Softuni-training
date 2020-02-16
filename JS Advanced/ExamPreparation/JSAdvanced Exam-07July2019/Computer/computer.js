class Computer {
    constructor(ramMemory, cpuGHz, hddMemory) {
        this.ramMemory = ramMemory;
        this.cpuGHz = cpuGHz;
        this.hddMemory = hddMemory;
        this.taskManager = [];
        this.installedPrograms = [];
    }

    installAProgram(name, requiredSpace) {
        if (this.hddMemory - requiredSpace < 0) {
            throw new Error("There is not enough space on the hard drive");
        }
        else {
            let program = { name, requiredSpace };
            this.installedPrograms.push(program);
            this.hddMemory -= requiredSpace;

            return program;
        }
    }

    uninstallAProgram(name) {
        let currentProgram = this.installedPrograms.find(p => p.name === name);

        if (!currentProgram) {
            throw new Error("Control panel is not responding");
        }

        this.hddMemory += currentProgram.requiredSpace;

        let index = this.installedPrograms.indexOf(currentProgram);
        this.installedPrograms.splice(index, 1);

        return this.installedPrograms;
    }

    openAProgram(name) {
        let program = this.installedPrograms.find(p => p.name === name);

        if (!program) {
            throw new Error(`The ${name} is not recognized`);
        }

        let isProgramOpen = this.taskManager.find(p => p.name === name);

        if (isProgramOpen) {
            throw new Error(`The ${name} is already open`);
        }

        let programRam = (program.requiredSpace / this.ramMemory) * 1.5;
        let programCPU = ((program.requiredSpace / this.cpuGHz) / 500) * 1.5;

        let currentRam = this.taskManager.reduce((acc, curr) => acc + curr.ramUsage, 0);
        let currentCPU = this.taskManager.reduce((acc, curr) => acc + curr.cpuUsage, 0);

        if (currentRam + programRam >= 100) {
            throw new Error(`${name} caused out of memory exception`);
        }
        if (currentCPU + programCPU >= 100) {
            throw new Error(`${name} caused out of cpu exception`);
        }

        let obj = {
            name,
            ramUsage: programRam,
            cpuUsage: programCPU
        }

        this.taskManager.push(obj);

        return obj;
    }

    taskManagerView() {
        if (this.taskManager.length === 0) {
            return "All running smooth so far";
        }

        let programs = [];

        this.taskManager.forEach(p => {
            programs.push(`Name - ${p.name} | Usage - CPU: ${p.cpuUsage.toFixed(0)}%, RAM: ${p.ramUsage.toFixed(0)}%`);
        });

        return programs.join('\n');
    }
}