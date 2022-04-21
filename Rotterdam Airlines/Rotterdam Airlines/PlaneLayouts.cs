using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotterdam_Airlines
{
    internal class PlaneLayouts
    {
        public static string[] getLayout(Flight flight)
        {
            string[] list = new string[13];
            if (flight == null) 
            {
                list = new string[13] {
                    "               ╭─────────┰──────────┸────────────────────┸──────────╮                   ╭╯     ╭╯     ",
                    "          ╭────╯         ┃                                          ╰──────────╮       ╭╯      │      ",
                    "      ╭───╯              ┃                                                     ╰───┰╮ ╭╯      ╭╯      ",
                    "   ╭──╯     ╭╮           ┃                                                         ┃╰─┴────╮  │       ",
                    " ╭─╯      ╭─╯│           ┃                      Uh Oh...                           ┃       ╰──┴╮      ",
                    "╭╯       ╭╯ ╭╯           ┃                                                         ┃           ╰╮     ",
                    "│        │  │            ┃           Er is geen vlucht geselecteerd!               ┃    ════════╪═════",
                    "╰╮       ╰╮ ╰╮           ┃                                                         ┃           ╭╯     ",
                    " ╰─╮      ╰─╮│           ┃           Selecteer eerst een vlucht om                 ┃       ╭──┬╯      ",
                    "   ╰──╮     ╰╯           ┃           stoelen uit te kiezen!                        ┃╭─┬────╯  │       ",
                    "      ╰───╮              ┃                                                     ╭───┸╯ ╰╮      ╰╮      ",
                    "          ╰────╮         ┃                                          ╭──────────╯       ╰╮      │      ",
                    "               ╰─────────┸──────────┰────────────────────┰──────────╯                   ╰╮     ╰╮     "
                };
            }
            else if (flight.PlaneType == "Boeing 737")
            {
                list = new string[13] {
                    "               ╭─────────┰────═────────────────────────────────────┸─────────═────═────────┸───────────────────────────────────╮                           ╭╯     ╭╯     ",
                    "          ╭────╯         ┃    ▲                                              ▲    ▲                                            ╰─────────────═──╮         ╭╯      │      ",
                    "      ╭───╯              ┃            XX XX XX XX XX XX XX XX XX XX XX XX XX   XX   XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX ╭───╮ ▲  ╰─────┰╮ ╭╯      ╭╯      ",
                    "   ╭──╯     ╭╮           ┃            XX XX XX XX XX XX XX XX XX XX XX XX XX   XX   XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX │   │          ┃╰─┴────╮  │       ",
                    " ╭─╯      ╭─╯│           ┃            XX XX XX XX XX XX XX XX XX XX XX XX XX   XX   XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX ╰───╯          ┃       ╰──┴╮      ",
                    "╭╯       ╭╯ ╭╯           ┃                                                                                                                            ┃           ╰╮     ",
                    "│        │  │            ┃                                                                                                                            ┃    ════════╪═════",
                    "╰╮       ╰╮ ╰╮           ┃                                                                                                                            ┃           ╭╯     ",
                    " ╰─╮      ╰─╮│           ┃  ╭───╮  XX XX XX XX XX XX XX XX XX XX XX XX XX XX   XX   XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX ╭───╮          ┃       ╭──┬╯      ",
                    "   ╰──╮     ╰╯           ┃  │   │  XX XX XX XX XX XX XX XX XX XX XX XX XX XX   XX   XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX │   │          ┃╭─┬────╯  │       ",
                    "      ╰───╮              ┃  ╰───╯  XX XX XX XX XX XX XX XX XX XX XX XX XX XX   XX   XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX ╰───╯ ▼  ╭─────┸╯ ╰╮      ╰╮      ",
                    "          ╰────╮         ┃    ▼                                              ▼    ▼                                            ╭─────────────═──╯         ╰╮      │      ",
                    "               ╰─────────┸────═────────────────────────────────────┰─────────═────═────────┰───────────────────────────────────╯                           ╰╮     ╰╮     ",
                };
            }
            else if (flight.PlaneType == "Airbus 330")
            {
                list = new string[13] {
                    "               ╭──────═──┰───────────────────────────═──────────────────────┸─────────────────────────────────┸───────┬─═───────────────────────────╮                           ╭╯     ╭╯     ",
                    "          ╭────╯      ▲  ┃         XX XX XX XX ╭───╮ ▲  XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX ╭───╮│ ▲  XX XX XX XX XX XX XX XX  ╰────────────────╮         ╭╯      │      ",
                    "      ╭───╯              ┃  XX XX  XX XX XX XX │   │    XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX │   ││    XX XX XX XX XX XX XX XX  XX XX XX XX XX XX╰──═──┰╮ ╭╯      ╭╯      ",
                    "   ╭──╯     ╭╮           ┃  XX XX  XX XX XX XX ╰───╯    XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX ╰───╯╵    XX XX XX XX XX XX XX XX  XX XX XX XX XX XX   ▲  ┃╰─┴────╮  │       ",
                    " ╭─╯      ╭─╯│           ┃                                                                                         ╭───╮                                                   ┃       ╰──┴╮      ",
                    "╭╯       ╭╯ ╭╯           ┃  XX XX   XX XX XX XX XX XX  XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX │   │  XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX     ┃           ╰╮     ",
                    "│        │  │            ┃  XX XX   XX XX XX XX XX XX  XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX ├───┤  XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX     ┃    ════════╪═════",
                    "╰╮       ╰╮ ╰╮           ┃          XX XX XX XX XX XX  XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX │   │  XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX     ┃           ╭╯     ",
                    " ╰─╮      ╰─╮│           ┃                                                                                         ╰───╯                                                   ┃       ╭──┬╯      ",
                    "   ╰──╮     ╰╯           ┃  XX XX  XX XX XX XX ╭───╮    XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX ╭───╮╷    XX XX XX XX XX XX XX XX  XX XX XX XX XX XX   ▼  ┃╭─┬────╯  │       ",
                    "      ╰───╮              ┃  XX XX  XX XX XX XX │   │    XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX │   ││    XX XX XX XX XX XX XX XX  XX XX XX XX XX XX╭──═──┸╯ ╰╮      ╰╮      ",
                    "          ╰────╮      ▼  ┃         XX XX XX XX ╰───╯ ▼  XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX ╰───╯│ ▼  XX XX XX XX XX XX XX XX  ╭────────────────╯         ╰╮      │      ",
                    "               ╰──────═──┸───────────────────────────═──────────────────────┰─────────────────────────────────┰───────┴─═───────────────────────────╯                           ╰╮     ╰╮     ",
                };
            }
            else if (flight.PlaneType == "Boeing 787")
            {
                list = new string[13] {
                    "               ╭──────═──┰───────────────────────═─┬────┸──────┬────────────────────────────────┸─────═────────────────────────────────┬───────═─╮                   ╭╯     ╭╯     ",
                    "          ╭────╯      ▲  ┃╭───╮            ╭───╮ ▲ │           │ XX XX XX XX XX XX XX XX XX XX ╭───╮  ▲  XX XX XX XX XX XX XX XX XX XX │ ╭───╮ ▲ ╰──────────╮       ╭╯      │      ",
                    "      ╭───╯              ┃│   │  XX XX XX  │   │   │ XX XX XX  │ XX XX XX XX XX XX XX XX XX XX │   │     XX XX XX XX XX XX XX XX XX XX │ │   │              ╰───┰╮ ╭╯      ╭╯      ",
                    "   ╭──╯     ╭╮           ┃│   │  XX XX XX  ╰───╯   ╵ XX XX XX  ╵ XX XX XX XX XX XX XX XX XX XX ╰───╯     XX XX XX XX XX XX XX XX XX XX ╵ ╰───╯                  ┃╰─┴────╮  │       ",
                    " ╭─╯      ╭─╯│           ┃╰───╯                                                                                                                                 ┃       ╰──┴╮      ",
                    "╭╯       ╭╯ ╭╯           ┃    ╷    XX XX XX            XX XX XX    XX XX XX XX XX XX XX XX XX ╷         XX XX XX XX XX XX XX XX XX XX XX XX                     ┃           ╰╮     ",
                    "│        │  │            ┃    │    XX XX XX            XX XX XX    XX XX XX XX XX XX XX XX XX │         XX XX XX XX XX XX XX XX XX XX XX XX                     ┃    ════════╪═════",
                    "╰╮       ╰╮ ╰╮           ┃    ╵                                    XX XX XX XX XX XX XX XX XX ╵         XX XX XX XX XX XX XX XX XX XX XX XX                     ┃           ╭╯     ",
                    " ╰─╮      ╰─╮│           ┃                                                                                                                                      ┃       ╭──┬╯      ",
                    "   ╰──╮     ╰╯           ┃       XX XX XX  ╭───╮   ╷ XX XX XX  ╷ XX XX XX XX XX XX XX XX XX XX ╭───╮     XX XX XX XX XX XX XX XX XX XX ╷ ╭───╮                  ┃╭─┬────╯  │       ",
                    "      ╰───╮              ┃       XX XX XX  │   │   │ XX XX XX  │ XX XX XX XX XX XX XX XX XX XX │   │     XX XX XX XX XX XX XX XX XX XX │ │   │              ╭───┸╯ ╰╮      ╰╮      ",
                    "          ╰────╮      ▼  ┃                 ╰───╯ ▼ │           │ XX XX XX XX XX XX XX XX XX XX ╰───╯  ▼  XX XX XX XX XX XX XX XX XX XX │ ╰───╯ ▼ ╭──────────╯       ╰╮      │      ",
                    "               ╰──────═──┸───────────────────────═─┴────┰──────┴────────────────────────────────┰─────═────────────────────────────────┴───────═─╯                   ╰╮     ╰╮     ",
                };
            }
            return list;
        }
    }
}
