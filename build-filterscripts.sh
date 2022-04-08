#!/bin/bash
cd filterscripts
for dir in */
do
    sampctl package ensure --dir "$PWD/$dir"
    sampctl package build --dir "$PWD/$dir"
done