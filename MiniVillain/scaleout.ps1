param([string]$instanceName = "Kevin")

$src = ".\Minion\bin\debug"
$dst = ".\Minion\bin\$instanceName"
$gru = ".\Gru\bin\debug\minion.txt"
 
# x-copy scaleout
copy-item -path $src -destination $dst -recurse -force

# set instance name
$xml = [xml](get-content "$dst\minion.exe.config")
$node = $xml.configuration.appSettings.add | where {$_.key -eq 'minion.name'}
$node.value = $instanceName
$xml.save((Resolve-Path $dst\minion.exe.config))

# update routing info with new minion`s info
$original = (get-content $gru) -join "`n"
set-content $gru $original"`n"$instanceName":localhost"

# execute new minion
Start-Process -FilePath "$dst\minion.exe"