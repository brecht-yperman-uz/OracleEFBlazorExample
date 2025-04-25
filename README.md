Create the view using
```
CREATE OR REPLACE VIEW VIRTUAL_NUMBERS AS
SELECT LEVEL AS RowNumber FROM DUAL CONNECT BY LEVEL <= 10000
```

Add the connection string to the user secrets for the project

Run the app
