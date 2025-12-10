var setA = new HashSet<int> { 1, 2, 3, 4, 5 };
var setB = new HashSet<int> { 4, 5, 6, 7, 8 };

Console.WriteLine("A: " + string.Join(", ", setA));
Console.WriteLine("B: " + string.Join(", ", setB));

// UNION the sum of both sets
var union = new HashSet<int>(setA);
union.UnionWith(setB);
Console.WriteLine("\nUnion: " + string.Join(", ", union));

// INTERSECT the common elements between sets
var intersect = new HashSet<int>(setA);
intersect.IntersectWith(setB);
Console.WriteLine("Intersect: " + string.Join(", ", intersect));

// EXCEPT difference between sets
var except = new HashSet<int>(setA);
except.ExceptWith(setB);
Console.WriteLine("Except (A - B): " + string.Join(", ", except));

// SYMMETRIC DIFFERENCE elements in either set but not in both
var symDiff = new HashSet<int>(setA);
symDiff.SymmetricExceptWith(setB);
Console.WriteLine("Symmetric Except: " + string.Join(", ", symDiff));

