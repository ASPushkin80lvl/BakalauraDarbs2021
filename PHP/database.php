<?php

$dbconn = pg_connect("host=localhost dbname=BakalauraDarbsDB user=postgres password=29465532");
$query = 'SELECT * FROM "Users" WHERE "Users"."Name"=\'PHP\';';

$result = pg_query($dbconn, $query);

$line = pg_fetch_array($result, null, PGSQL_ASSOC);
echo "{$line['Id']} -- {$line['Name']}";

pg_free_result($result);
pg_close($dbconn);