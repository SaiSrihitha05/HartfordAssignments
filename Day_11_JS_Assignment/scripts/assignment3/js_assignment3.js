let cells = [...document.querySelectorAll('.cell')];
let resetGameBtn = document.querySelector('#resetGameBtn');
let newGameBtn = document.querySelector('#newGameBtn');
let messageBox = document.querySelector('.message-box');
let statusMsg = document.querySelector('#statusMsg');

let isOTurn = true;

const winningCombos = [
    [0, 1, 2],
    [0, 3, 6],
    [0, 4, 8],
    [1, 4, 7],
    [2, 5, 8],
    [2, 4, 6],
    [3, 4, 5],
    [6, 7, 8]
];

cells.forEach((cell) => {
    cell.addEventListener('click', () => {
        if (isOTurn) {
            cell.innerText = 'O';
            cell.style.color = 'green';
        } else {
            cell.innerText = 'X';
            cell.style.color = 'black';
        }

        cell.disabled = true;
        isOTurn = !isOTurn;
        checkResult();
    });
});

const enableCells = () => {
    for (let cell of cells) {
        cell.disabled = false;
        cell.innerText = "";
    }
};

const disableCells = () => {
    for (let cell of cells) {
        cell.disabled = true;
    }
};

const displayWinner = (winner) => {
    statusMsg.innerText = `Congratulations, Winner is ${winner}`;
    messageBox.classList.remove('hidden');
    disableCells();
};

const checkResult = () => {
    for (let combo of winningCombos) {
        let a = cells[combo[0]].innerText;
        let b = cells[combo[1]].innerText;
        let c = cells[combo[2]].innerText;
        
        if (a && a === b && b === c) {
            displayWinner(a);
            return;
        }
    }

    let isDraw = cells.every(cell => cell.innerText !== "");
    if (isDraw) {
        statusMsg.innerText = "Match Drawn";
        messageBox.classList.remove('hidden');
    }
};

const resetGame = () => {
    isOTurn = true;
    enableCells();
    messageBox.classList.add('hidden');
};

newGameBtn.addEventListener('click', resetGame);
resetGameBtn.addEventListener('click', resetGame);
