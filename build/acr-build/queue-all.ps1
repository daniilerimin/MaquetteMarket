Param(
    [parameter(Mandatory=$false)][string]$acrName,
    [parameter(Mandatory=$false)][string]$gitUser,
    [parameter(Mandatory=$false)][string]$repoName="MaquetteMarketOnContainers",
    [parameter(Mandatory=$false)][string]$gitBranch="dev",
    [parameter(Mandatory=$true)][string]$patToken
)

$gitContext = "https://github.com/$gitUser/$repoName"

$services = @( 
    @{ Name="MaquetteMarketBasket"; Image="MaquetteMarket/basket.api"; File="src/Services/Basket/Basket.API/Dockerfile" },
    @{ Name="MaquetteMarketCatalog"; Image="MaquetteMarket/catalog.api"; File="src/Services/Catalog/Catalog.API/Dockerfile" },
    @{ Name="MaquetteMarketIdentity"; Image="MaquetteMarket/identity.api"; File="src/Services/Identity/Identity.API/Dockerfile" },
    @{ Name="MaquetteMarketordering"; Image="MaquetteMarket/ordering.api"; File="src/Services/Ordering/Ordering.API/Dockerfile" },
	@{ Name="MaquetteMarketorderingbg"; Image="MaquetteMarket/orderprocessor"; File="src/Services/Ordering/OrderProcessor/Dockerfile" },
    @{ Name="MaquetteMarketWebspa"; Image="MaquetteMarket/webspa"; File="src/Web/WebSPA/Dockerfile" },
    @{ Name="MaquetteMarketWebmvc"; Image="MaquetteMarket/webmvc"; File="src/Web/WebMVC/Dockerfile" },
    @{ Name="MaquetteMarketWebstatus"; Image="MaquetteMarket/webstatus"; File="src/Web/WebStatus/Dockerfile" },
    @{ Name="MaquetteMarketpayment"; Image="MaquetteMarket/paymentprocessor"; File="src/Services/Payment/PaymentProcessor/Dockerfile" },
    @{ Name="MaquetteMarketocelotapigw"; Image="MaquetteMarket/ocelotapigw"; File="src/ApiGateways/ApiGw-Base/Dockerfile" },
    @{ Name="MaquetteMarketmobilMaquetteMarketpingagg"; Image="MaquetteMarket/mobilMaquetteMarketpingagg"; File="src/ApiGateways/Mobile.Bff.Shopping/aggregator/Dockerfile" },
    @{ Name="MaquetteMarketWebshoppingagg"; Image="MaquetteMarket/webshoppingagg"; File="src/ApiGateways/Web.Bff.Shopping/aggregator/Dockerfile" },
    @{ Name="MaquetteMarketorderingsignalrhub"; Image="MaquetteMarket/ordering.signalrhub"; File="src/Services/Ordering/Ordering.SignalrHub/Dockerfile" }
)

$services |% {
    $bname = $_.Name
    $bimg = $_.Image
    $bfile = $_.File
    Write-Host "Setting ACR build $bname ($bimg)"    
    az acr build-task create --registry $acrName --name $bname --image ${bimg}:$gitBranch --context $gitContext --branch $gitBranch --git-access-token $patToken --file $bfile
}
