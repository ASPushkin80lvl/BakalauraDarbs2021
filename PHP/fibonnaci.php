<?php

function Fibonnaci(int $num) {
    $numbers = array();
    $numbers = '0';
    $numbers = '1';
    $n1 = 0; $n2 = 1;
    for ($i = 2; $i < $num; $i++)
    {
        $n3 = $n1 + $n2;
        $numbers[] = strval($n3);
        $n1 = $n2;
        $n2 = $n3;
    }
    return join(" | ", $numbers);
}

$data = json_decode(file_get_contents('php://input'));
echo Fibonnaci($data->{"num"});