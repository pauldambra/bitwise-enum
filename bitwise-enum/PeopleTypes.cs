namespace bitwise_enum
{
    using System;

    [Flags]
    public enum PeopleTypes
    {
        Square = 0,

        Dweeb = 1,

        Nerd = 2,

        Geek = 4,

        Fanboy = 8,

        Gamer = 16,

        Trekkie = 32,

        CoolestType = Geek | Trekkie
    }
}