function returnResult(inputMsgValue)
    local result = "" --Объявляем строку с результатом

    local values = {}

    values = mysplit(inputMsgValue, ' ')
    
    local sum = 0

    for key, value in pairs(values) do
        sum = sum + value
    end

    result = sum

    return result
end

function mysplit (inputstr, sep)
    if sep == nil then
            sep = "%s"
    end
    local t={}
    for str in string.gmatch(inputstr, "([^"..sep.."]+)") do
            table.insert(t, str)
    end
    return t
end



math.round = function(num, idp) --Пользовательский метод дополняющий библиотеку lua
    local mult = 10^(idp or 0)
    return math.floor(num * mult + 0.5) / mult
end    