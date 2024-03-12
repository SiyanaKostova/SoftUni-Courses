function solve(input)
{
    const number = input.shift()
    const collectionMusic = {}
    for (let index = 0; index < number; index++) {
        let musicPiece = input.shift().split('|')
        let piece = musicPiece[0]
        collectionMusic[piece] = musicPiece
        
    }

    let tokens = input.shift().split('|')
    while (tokens[0]!="Stop") {
        let diffCommand = tokens[0]
        if (diffCommand=="Add") {
            let getPiece = tokens[1]
            let getComposer = tokens[2]
            let getKey = tokens[3]

            if (!collectionMusic.hasOwnProperty(getPiece)) {
                let token = [getPiece,getComposer,getKey]
                collectionMusic[getPiece]=token
                console.log(`${getPiece} by ${getComposer} in ${getKey} added to the collection!`)
                
            }
            else
            {
                console.log(`${getPiece} is already in the collection!`)
            }
        }
        else if (diffCommand=="Remove") {
            let getPiece = tokens[1]
            let IsItThere = collectionMusic.hasOwnProperty(getPiece)
            if (IsItThere) {
                console.log(`Successfully removed ${getPiece}!`)
                delete collectionMusic[getPiece]
            }
            else
            {
                console.log(`Invalid operation! ${getPiece} does not exist in the collection.`)
            }

            
        }
        else if (diffCommand=="ChangeKey") {
            let getPiece = tokens[1]
            let newKey = tokens[2]
            let IsItThere = collectionMusic.hasOwnProperty(getPiece)
            if (IsItThere) {
                collectionMusic[getPiece][2]=newKey
                console.log(`Changed the key of ${getPiece} to ${newKey}!`)
            }
            else{
                console.log(`Invalid operation! ${getPiece} does not exist in the collection.`)
            }

        }



        tokens= input.shift().split('|')
    }

    for (let element in collectionMusic) {
        let value = collectionMusic[element]

        console.log(`${value[0]} -> Composer: ${value[1]}, Key: ${value[2]}`)
    }
   
}

solve([
    '3',
    'Fur Elise|Beethoven|A Minor',
    'Moonlight Sonata|Beethoven|C# Minor',
    'Clair de Lune|Debussy|C# Minor',
    'Add|Sonata No.2|Chopin|B Minor',
    'Add|Hungarian Rhapsody No.2|Liszt|C# Minor',
    'Add|Fur Elise|Beethoven|C# Minor',
    'Remove|Clair de Lune',
    'ChangeKey|Moonlight Sonata|C# Major',
    'Stop'
  ]
  )