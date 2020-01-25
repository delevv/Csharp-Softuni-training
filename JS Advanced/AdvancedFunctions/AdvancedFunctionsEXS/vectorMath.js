(() => {
    return {
        add: (first, second) => [first[0] + second[0], first[1] + second[1]],
        multiply: (vector, scalar) => [vector[0] * scalar, vector[1] * scalar],
        length: vector => Math.sqrt(vector[0] * vector[0] + vector[1] * vector[1]),
        dot: (first, second) => first[0] * second[0] + first[1] * second[1],
        cross: (first, second) => first[0] * second[1] - first[1] * second[0]
    }
})();