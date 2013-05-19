#!/usr/bin/bash
echo $1 -- $2
cd ../bin
cd jar
nohup java -jar fpclassifier.jar $1 $2 >some.log 2>&1 </dev/null &
