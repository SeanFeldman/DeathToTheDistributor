$src = ".\Minion\bin"
$gru = ".\Gru\bin\debug\minion.txt"

# reset routing info
set-content $gru "Dave:localhost"
 
Get-ChildItem $src -Exclude "debug" | ? { $_.PSIsContainer } |  Remove-Item -Recurse -Force