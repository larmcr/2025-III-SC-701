
IDal dal = new DalNoSql();

IRandom random = new RandomTen();

var bllGet = new BllGet(dal, random);

var bllRem = new BllRem(dal);

bllGet.Get("People");

bllRem.Remove("Accounts");