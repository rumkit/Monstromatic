curl.exe -F caption="The new release is here!" -F name=document -F document=@Monstromatic-$env:csproj_version.zip -H "Content-Type:multipart/form-data" "https://api.telegram.org/bot$env:TELEGRAM_BOT_TOKEN/sendDocument?chat_id=$env:TELEGRAM_CHAT_ID"

