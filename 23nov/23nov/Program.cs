﻿//Console.WriteLine(" ______________________________________________________________________________________________________________________\r\n|    |___________________________________________________|    |___________________________________________________|    |\r\n|____|                                                   |____|                                                   |____|\r\n| |                                                                                                                  | |\r\n| |                                                                                                                  | |\r\n| |                                                                                                                  | |\r\n| |                                                                                                                  | |\r\n| |                                                                                                                  | |\r\n| |                                                                                                                  | |\r\n| |                                                                                                                  | |\r\n| |                                                                                                                  | |\r\n| |                                                                                                                  | |\r\n| |                                                                                                                  | |\r\n| |                                                                                                                  | |\r\n| |                                                                                                                  | |\r\n| |                                                                                                                  | |\r\n| |                                                                                                                  | |\r\n| |                                                                                                                  | |\r\n| |                                                                                                                  | |\r\n| |                                                                                                                  | |\r\n| |                                                                                                                  | |\r\n| |                                                                                                                  | |\r\n| |__                                                     ____                                                     __| |\r\n|    |___________________________________________________|    |___________________________________________________|    |\r\n|____|___________________________________________________|____|___________________________________________________|____|");
//Console.WriteLine(" ______________________________________________________________________________________________________________________ ".Length);
string mapString = " ______________________________________________________________________________________________________________________ |    |___________________________________________________|    |___________________________________________________|    ||____|                                                   |____|                                                   |____|| |                                                                                                                  | || |                                                                                                                  | || |                                                                                                                  | || |                                                                                                                  | || |                                                                                                                  | || |                                                                                                                  | || |                                                                                                                  | || |                                                                                                                  | || |                                                                                                                  | || |                                                                                                                  | || |                                                                                                                  | || |                                                                                                                  | || |                                                                                                                  | || |                                                                                                                  | || |                                                                                                                  | || |                                                                                                                  | || |                                                                                                                  | || |                                                                                                                  | || |                                                                                                                  | ||_|__                                                     ____                                                     __|_||    |___________________________________________________|    |___________________________________________________|    ||____|___________________________________________________|____|___________________________________________________|____|";
char[,] map = new char[25,120];
for (int i = 0; i < 25; i++)
{
    for (int j = 0, k = i * 120; j < 120; j++)
    {
        map[i, j] = mapString[k];
        k++;
    }
}
char[,] mapCopy = map;
char[,] obj = { { ' ', '_', '_',' ' }, {'|', '_', '_','|'} };
void setObjPos()
{
    
}
//for (int i = 0; i < 25; i++)
//{
//    for (int j = 0; j < 120; j++)
//    {
//        Console.Write(map[i, j]);
//    }
//    Console.WriteLine();
//}