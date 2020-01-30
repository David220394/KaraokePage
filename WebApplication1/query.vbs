
  Set xl = CreateObject("Excel.Application")
    xl.Visible = False
    Set wb = xl.Workbooks.Open("C:\Users\sylvio.brandon.david\Desktop\Karaoke\Sharepoint_Console\query.xlsx")
    wb.RefreshAll
    wb.Save
    wb.Close
   


