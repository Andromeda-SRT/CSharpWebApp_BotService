function returnResult(inputMsgValue)
    local result = "" --Объявляем строку с результатом

    local values = {}

    values = mysplit(inputMsgValue, ' ')
    
    local mult = 1;

    for key, value in pairs(values) do
        mult = mult * value
    end

    result = mult

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