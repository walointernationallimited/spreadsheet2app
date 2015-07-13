# spreadsheet2app
spreadsheet2app is a project that contains steps in using Google Spreadsheet for data feed in JSON format to applications such as smartphone (Android, iOS, ...) apps. The document was drafted on 12 July 2015. It is used as reference for
<br/>- <a href="#spreadsheet2app_1">Publishing JSON feed from Google spreadsheet</a>
<br/>- <a href="#spreadsheet2app_2">Publishing web image from Google Drive</a>

<br/>

<a name="spreadsheet2app_1" />
<pre>
<h1>Publishing JSON feed from Google spreadsheet</h1>

- Login to Google Drive
http://drive.google.com/

- Create Folder "spreadsheet2app"
Right mouse button click on "My Drive"
Select "New folder..."
Label it as "spreadsheet2app"

- Create Spreadsheet "spreadsheet2app_data"
Double click on folder named "spreadsheet2app"
Right click > New file... > Google Sheets
Click on "Untitled spreadsheet" and rename it as "spreadsheet2app_data"

- Create data for Spreadsheet "spreadsheet2app_data"
- In CSV format
id,title,description,imagelink,lastinserted
1,Item One T,Item One D,http://drive.google.com/uc?export=view&id=<ID>&,7/13/2015
2,Item Two T,Item Two D,http://drive.google.com/uc?export=view&id=<ID>&,7/13/2015

- Publish Spreadsheet "spreadsheet2app_data" to the web
Click "File" tab, then select "Publish to the web..."
Click "Publish"
Copy ID section ... in the link of the format: https://docs.google.com/spreadsheets/d/.../pub?output=html

- Get the published feed for Spreadsheet "spreadsheet2app_data"
Logout from Google Drive
Browse the link to the published feed by pasting the copied ID section ... into the link:
https://spreadsheets.google.com/feeds/list/.../od6/public/values?alt=json&
</pre>

<a name="spreadsheet2app_2" />
<pre>
<h1>Publishing web image from Google Drive</h1>

- Login to Google Drive
http://drive.google.com/

- Create Folder "My Drive/spreadsheet2app/items"
Right mouse button click on "spreadsheet2app"
Select "New folder..."
Label it as "items"

</pre>

<br/>
