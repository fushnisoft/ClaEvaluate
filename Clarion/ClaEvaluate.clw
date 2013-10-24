  PROGRAM

  Include('ConsoleSupport.inc'),ONCE

                        MAP
Main                      PROCEDURE()
                        END
  CODE
  Main()

! ----------------------------------------------------------------------------------
Main                    PROCEDURE()
Console                   ConsoleSupport
rv CSTRING(1024) 
i LONG
  CODE

  IF Console.Init() 
    Halt()
  END
  LOOP i = 1 TO 255
    rv = EVALUATE(Command(i))
    IF rv = ''
      BREAK
    END
    IF ErrorCode()
      rv = 'Error: ' & Error()
    END
    Console.WriteLine(rv)
  END
