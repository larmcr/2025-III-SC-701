
var dal = new DalNoSql();

var bllGet = new BllGet(dal);

var bllRem = new BllRem(dal);

bllGet.Get("People");

bllRem.Remove("Accounts");