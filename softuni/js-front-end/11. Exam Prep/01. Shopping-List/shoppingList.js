function solve(input)
{
    let list = input.shift().split('!')

    let firstCommand = input.shift()
    while (firstCommand!="Go Shopping!") {
        let tokens = firstCommand.split(" ")
        let getCommand = tokens[0]

        if (getCommand=="Urgent") {
            let getItem = tokens[1]
            if (!list.includes(getItem)) {
                list.unshift(getItem)
            }
        }
        else if (getCommand=="Unnecessary") {
            let getItem = tokens[1]
            if (list.includes(getItem)) {
                let itemIndex = list.indexOf(getItem)
               list.splice(itemIndex,1)
            }
        }
        else if (getCommand=="Correct") {
            let oldItem=tokens[1]
            let NewItem=tokens[2]

            if (list.includes(oldItem)) {
                let itemIndex = list.indexOf(oldItem)
                list[itemIndex]=NewItem

            }

        }
        else if (getCommand=="Rearrange") {
            let getItem = tokens[1]
            if (list.includes(getItem)) {
                let itemIndex = list.indexOf(getItem)
               list.splice(itemIndex,1)
               list.push(getItem)
            }

        }
        firstCommand=input.shift()
    }

    console.log(list.join(', '))
}

solve
(["Tomatoes!Potatoes!Bread!Milk",
"Unnecessary Milk",
"Urgent Tomatoes",
"Go Shopping!"])