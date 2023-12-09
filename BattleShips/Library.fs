namespace BattleShips

module Board =
    let print() =
      let emptyBoard = """
 | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |
0|   |   |   |   |   |   |   |   |   |   |
1|   |   |   |   |   |   |   |   |   |   |
2|   |   |   |   |   |   |   |   |   |   |
3|   |   |   |   |   |   |   |   |   |   |
4|   |   |   |   |   |   |   |   |   |   |
5|   |   |   |   |   |   |   |   |   |   |
6|   |   |   |   |   |   |   |   |   |   |
7|   |   |   |   |   |   |   |   |   |   |
8|   |   |   |   |   |   |   |   |   |   |
9|   |   |   |   |   |   |   |   |   |   |
"""

      printf "%s" emptyBoard
