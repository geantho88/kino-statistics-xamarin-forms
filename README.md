# kino-statistics-xamarin-forms
Draws analysis mobile App for the famous game of OPAP in Greece "Kino" 

Try your Luck! This application contains statistical analysis for the game of OPAP Kino. The
Organization of Football Prognostics (OPAP) is a Greek company of organizing and gaming.

Headquartered in Peristeri Attica, for many years was the public gambling monopoly and still
has the exclusive right to organize and gaming management in Greece.
The app requires internet connection in order to download and analyze the most recent
draws and export statistics data like:

• Creating Random numbers according to possibility draw in next draws
• Count numbers show
• Anticipating the next numbers based on their incidence
• Viewing numbers frequency per hour
• Save favorite numbers and viewing statistics for these

This application has been created using Xamarin forms with Xamarin studio. The Shared PCL
code comes 100% from kino statistics application for windows phone (see windows phone
projects) The UI is rendered using Xamarin forms.

Data update and data analysis is performed every time the app is launching or manually by
pressing the update button in the main page .

Data analysis is performed with using of linq to objects in many static lists. There is no option
of saving the data permanently (e.g Sqlite) due to the draws are repeated every 5 minutes.
Kino statistics engine is responsible for extraction of all the data services…

The download of the data is performed from official opap webservice
