class Extensible {
    constructor() {
        Extensible.prototype.id = Extensible.prototype.id !== undefined ? Extensible.prototype.id + 1 : 0;
        this.id = Extensible.prototype.id;
    }
    extend(template) {
        Object.entries(template).forEach(([key, value]) => {
            if (typeof value === 'function') {
                Extensible.prototype[key] = value;
            }
            else {
                this[key] = value;
            }
        });
    }
}