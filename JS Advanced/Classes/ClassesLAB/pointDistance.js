class Point {
    constructor(x, y) {
        this.x = x;
        this.y = y;
    }
    static distance(firstPoint, secondPoint) {
        return Math.sqrt((firstPoint.x - secondPoint.x) ** 2 + (firstPoint.y - secondPoint.y) ** 2);
    }
}