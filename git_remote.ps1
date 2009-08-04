$names = ("xerxesb","dtchepak","anthonyegerton","davidg","djhmateer","virk0009","crgsoftware","lama","davidjpbcourse")

$names | foreach-object { . git remote add $_ "git://github.com/{$_}/nbdn_2009_august_sydney.git"}


