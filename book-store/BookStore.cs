using System;
using System.Linq;
using System.Collections.Generic;

public static class BookStore
{
    public static double Total(IEnumerable<int> books)
    {
        var bookList = Enumerable.Range(1, 5).Select(x => books.Count(b => b == x)).OrderBy(n => n).ToList();

        // Group books in largest possible groups
        for (int i = 4; i > 0; i--)
        {
            bookList[i] -= bookList[i - 1];
        }

        // Two_groups_of_four_is_cheaper_than_group_of_five_plus_group_of_three
        int fiveThreeToFourFour = Math.Min(bookList[0], bookList[2]);
        bookList[1] += 2 * fiveThreeToFourFour;
        bookList[0] -= fiveThreeToFourFour;
        bookList[2] -= fiveThreeToFourFour;

        //Group_of_four_plus_group_of_two_is_cheaper_than_two_groups_of_three
        // int threeThreeToFourTwo = bookList[2] / 2;
        // bookList[2] -= 2 * threeThreeToFourTwo;
        // bookList[1] += threeThreeToFourTwo;
        // bookList[3] += threeThreeToFourTwo;

        return (0.75 * 5 * bookList[0] + 0.8 * 4 * bookList[1] + 0.9 * 3 * bookList[2] + 0.95 * 2 * bookList[3] + bookList[4]) * 8;
    }
}
