function solve(input) {

    let index = 0;
    let countNegativeGrades = Number(input[index]);
    index++;

    let command = input[index];
    index++;
    let counter = 0;
    let sumGrade = 0;
    let counterProblems = 0;
    let isBreakNeed = false;
    let lastProblem = '';

    while (command !== 'Enough') {
        let taskName = command;
        lastProblem = taskName;
        let grade = Number(input[index]);
        index++;
        counterProblems++;
        sumGrade += grade;

        if (grade <= 4.00) {
            counter++;
        }

        if (counter === countNegativeGrades) {
            console.log(`You need a break, ${counter} poor grades.`);
            isBreakNeed = true;
            break;
        }

        command = input[index];
        index++;
    }

    if (!isBreakNeed) {
        let avg = sumGrade / counterProblems;
        console.log(`Average score: ${avg.toFixed(2)}`);
        console.log(`Number of problems: ${counterProblems}`);
        console.log(`Last problem: ${lastProblem}`);
    }
}
solve(["3",
    "Money",
    "6",
    "Story",
    "4",
    "Spring Time",
    "5",
    "Bus",
    "6",
    "Enough"])
