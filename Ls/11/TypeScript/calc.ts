
const sum = (a: number, b: number): number => a + b;

const four: number = sum(1, 3);

const five: number = sum(1, four);

console.info("four: " + four);

console.info("five: " + five);