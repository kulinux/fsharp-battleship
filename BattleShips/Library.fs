namespace BattleShips

module Board =

    type Ship =
        | Carrier = 1
        | Destroyer = 2
        | Gunship = 3

    type Coordinate = { x: int;  y: int }

    type ShipInBoard = {coordinates: Coordinate; ship: Ship}

    type Shots = Coordinate list

    type private GameState = ShipInBoard list * Shots

    let private printRow (number: int, shots: Shots) =
        let shotInThisLine =
            shots
            |> List.filter (fun shot -> shot.x = number)
            |> List.map (fun shot -> shot.y)


        let shots =
            [ 0..10 ]
            |> List.map (fun index ->
                match shotInThisLine |> List.contains index with
                | true -> 'o'
                | false -> ' ')


        printfn
            "%d| %c | %c | %c | %c | %c | %c | %c | %c | %c | %c |"
            number
            shots[0]
            shots[1]
            shots[2]
            shots[3]
            shots[4]
            shots[5]
            shots[6]
            shots[7]
            shots[8]
            shots[9]



    let private printGame (state: GameState) =
        let header = """ | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |"""

        printfn "%s" header

        for i in 0..9 do
            printRow (i, snd state)


    type Game(stateIn: GameState) =
        let state = stateIn

        member self.fire(x: int, y: int) : Game =
            let nextState =
                match state with
                | (ships, shots) -> (ships, {x = x; y = y} :: shots)

            Game nextState

        member self.print() : unit = printGame state

        member self.start (ships: ShipInBoard list): Game = Game([], [])

        member self.printShips() : unit = () 


    let emptyGame () : Game = Game([], [])