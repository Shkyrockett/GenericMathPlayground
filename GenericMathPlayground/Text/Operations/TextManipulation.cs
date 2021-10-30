// <copyright file="TextManipulation.cs" company="Shkyrockett" >
//     Copyright © 2021 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

namespace GenericMathPlayground.Text;

/// <summary>
/// 
/// </summary>
public static partial class TextManipulation
{
    /// <summary>
    /// Retrieves the first word from a space delimited string.
    /// </summary>
    /// <param name="text">The string of text.</param>
    /// <returns>Returns the first set of characters from the string up to the first space character, or the entire trimmed string if there are no spaces. Returns null if no words are found.</returns>
    public static string? GetFirstWord(this string text)
    {
        text = text.Trim();
        int length = text.IndexOf(' ') is int l ? l == -1 ? text.Length : l : 0;
        return text[..length];
    }

    /// <summary>
    /// Retrieves the second word from a space delimited string.
    /// </summary>
    /// <param name="text">The string of text.</param>
    /// <returns>Returns the first word following the first space  of a trimmed string up to the third space, or end of string. Returns null if no words are found.</returns>
    public static string? GetSecondWord(this string text)
    {
        text = text.Trim();
        int firstIndex = text.IndexOf(' ');
        if (firstIndex == -1)
        {
            return null;
        }

        int secondIndex = text.IndexOf(' ', firstIndex) is int l ? l == -1 ? text.Length : l : 0;
        return text.Substring(firstIndex, secondIndex);
    }
}
