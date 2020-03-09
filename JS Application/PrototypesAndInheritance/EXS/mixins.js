function solve() {
    function computerQualityMixin(classToExtend) {
        classToExtend.prototype.getQuality = function () {
            return (this.processorSpeed + this.ram + this.hardDiskSpace) / 3;
        };
        classToExtend.prototype.isFast = function () {
            return this.processorSpeed > this.ram / 4;
        };
        classToExtend.prototype.isRoomy = function () {
            return this.hardDiskSpace > Math.floor(this.ram * this.processorSpeed);
        };
    }

    function styleMixin(classToExtend) {
        classToExtend.prototype.isFullSet = function () {
            let keyboard = this.keyboard.manufacturer === this.manufacturer;
            let monitor = this.monitor.manufacturer === this.manufacturer;

            return keyboard && monitor;
        };
        classToExtend.prototype.isClassy = function () {
            let battery = this.battery.expectedLife >= 3;
            let color = this.color === "Silver" || this.color === "Black";
            let weight = this.weight < 3;

            return battery && color && weight;
        };
    }

    return {
        computerQualityMixin,
        styleMixin
    };
}