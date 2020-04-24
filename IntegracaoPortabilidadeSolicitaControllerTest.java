package com.grupopan.bancodigital.portabilidade.http;

import static io.restassured.RestAssured.given;
import static org.hamcrest.Matchers.containsString;
import static org.hamcrest.Matchers.is;
import java.io.IOException;
import org.apache.commons.lang3.reflect.FieldUtils;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.mockito.MockitoAnnotations;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.context.embedded.LocalServerPort;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.http.HttpEntity;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpMethod;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.test.context.ActiveProfiles;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;
import org.springframework.web.client.RestTemplate;
import org.springframework.web.util.UriComponentsBuilder;

import com.fasterxml.jackson.databind.ObjectMapper;
import com.grupopan.application.manager.config.data.ApplicationManagerConfigurationProperties;
import com.grupopan.application.manager.gateway.AccessManagerGateway;
import com.grupopan.application.manager.gateway.data.output.CredentialsIntegrationOutput;
import com.grupopan.autbank.soap.exception.AutbankException;
import com.grupopan.autbank.soap.exception.Fault;
import com.grupopan.autbank.soap.services.portabilidade.PortabilidadeService;
import com.grupopan.autbank.soap.wsdl.portabilidade.SolicitaPortabilidade;
import com.grupopan.bancodigital.portabilidade.config.properties.EndpointServiceProperties;
import com.grupopan.bancodigital.portabilidade.config.properties.HeaderPortabilidadePropeties;
import com.grupopan.bancodigital.portabilidade.config.properties.ServicePortabilidadeProperties;
import com.grupopan.bancodigital.portabilidade.gateway.SolicitaPortabilidadeGateway;
import com.grupopan.bancodigital.portabilidade.gateway.data.response.ConsultaDiaUtilResponse;
import com.grupopan.bancodigital.portabilidade.matchers.PanMatchers;
import static org.mockito.Matchers.eq;

@ActiveProfiles("dev")
@RunWith(SpringJUnit4ClassRunner.class)
@SpringBootTest(webEnvironment = SpringBootTest.WebEnvironment.RANDOM_PORT)
public class IntegracaoPortabilidadeSolicitaControllerTest {

	@LocalServerPort
	private Integer port;

	@Mock
	private PortabilidadeService portabilidadeService;

	@Autowired
	private ObjectMapper objectMapper;

	@Mock
	private RestTemplate restTemplate;

	@Autowired
	private AccessManagerGateway accessManagerGateway;

	@Autowired
	private ApplicationManagerConfigurationProperties accessManagerGatewayProperties;
	
	@Autowired
	private EndpointServiceProperties endpointServiceProperties;
	
	@Autowired
	private ServicePortabilidadeProperties properties;

	@Autowired
	private SolicitaPortabilidadeGateway solicitaPortabilidadeGateway;
	
	@Autowired
	private HeaderPortabilidadePropeties portabilidadePropeties;

	@Before
	public void setUp() throws IOException, IllegalAccessException {

		MockitoAnnotations.initMocks(this);

		FieldUtils.writeDeclaredField(accessManagerGateway, "restTemplate", restTemplate, true);
		FieldUtils.writeDeclaredField(solicitaPortabilidadeGateway, "portabilidadeService", portabilidadeService, true);		

		HttpHeaders accessManagerRequestHeader = objectMapper.readValue(
			"{\"Content-Type\":[\"application/json\"],\"APPLICATION-ID\":[\"bancodigital\"],\"API-KEY\":[\"n6AosBCdUfy13ul7Vg4fYZVWxbXhuyVP\"]}",
			HttpHeaders.class);
		
		HttpHeaders dataUtilRequestHeader = objectMapper.readValue(
				"{\"Content-Type\":[\"application/json\"],\"dataInicio\":[\"13/04/2020\"],\"origem\":[\"rest-assured\"]}",
				HttpHeaders.class);

		HttpHeaders accessManagerResponseHeader = objectMapper.readValue(
			"{\"Content-Type\":[\"application/json;charset=UTF-8\"],\"Date\":[\"Fri, 31 Jan 2020 15:45:31 GMT\"],\"Server\":[\"nginx/1.14.1\"],\"X-Application-Context\":[\"service--application-manager:dev,live:5000\"],\"Content-Length\":[\"97\"],\"Connection\":[\"keep-alive\"]}",
			HttpHeaders.class);
		
		HttpHeaders dataUtilResponseHeader = objectMapper.readValue(
				"{\"Connection\":[\"keep-alive\"],\"Content-Type\":[\"application/json;charset=UTF-8\"],\"Context-Path\":[\"/dia-util/consulta/10\"],\"Date\":[\"Mon, 13 Apr 2020 18:48:45 GMT\"],\"Server\":[\"nginx/1.14.1\"],\"TraceId\":[\"ee4dfe6ac8a3bab7\"],\"transfer-encoding\":[\"chunked\"],\"X-Application-Context\":[\"service--bancos:dev:5000\"]}",
				HttpHeaders.class);

		CredentialsIntegrationOutput accessManagerResponseBody = objectMapper.readValue(
			"{\"metadata\":{\"stage\":\"dev,live\",\"type\":\"object\",\"step\":null,\"info\":null},\"results\":{\"claims\":{}}}",
			CredentialsIntegrationOutput.class);
		
		ConsultaDiaUtilResponse cosultaDiaUtilResponseBody = objectMapper.readValue(
				"{\"metadata\":{\"stage\":\"dev\",\"type\":\"object\"},\"results\":{\"dataProximoDiaUtil\":\"28/04/2020\"}}",
				ConsultaDiaUtilResponse.class);

		Mockito.when(restTemplate.exchange(
			eq(UriComponentsBuilder.fromHttpUrl(endpointServiceProperties.getServiceBanco().getEndpointConsultaDataUtil()).path(String.valueOf(properties.getQtdDiasUtil())).toUriString()),
			eq(HttpMethod.GET),
			eq(new HttpEntity<>(dataUtilRequestHeader)),
			eq(ConsultaDiaUtilResponse.class)))
			.thenReturn(new ResponseEntity<>(cosultaDiaUtilResponseBody, dataUtilResponseHeader, HttpStatus.OK));
		
		Mockito.when(restTemplate.exchange(
				eq(accessManagerGatewayProperties.getClaims()),
				eq(HttpMethod.GET),
				eq(new HttpEntity<>(accessManagerRequestHeader)),
				eq(CredentialsIntegrationOutput.class)))
				.thenReturn(new ResponseEntity<>(accessManagerResponseBody, accessManagerResponseHeader, HttpStatus.OK));

		SolicitaPortabilidade solicitaPortabilidadeAndamentoRequest = objectMapper.readValue(
			"{\"codBancoOrigem\":\"0341\",\"cnpjEmprdr\":\"64595202000106\",\"denSocEmprdr\":\"EMPREENDIMENTO RRRR SA\",\"codColigada\":\"001\",\"codAgencia\":\"00019\",\"nroConta\":\"0092568450\",\"cpfCliente\":\"21887127062\",\"sisOrigem\":\"DBAPP\"}",
			SolicitaPortabilidade.class);	
		
		Fault solicitaPortabilidadeAndamentoFault = objectMapper.readValue(
				"{\"faultCode\":\"13000108\",\"faultMessage\":\"Solicitação de Portabilidade já cadastrada.(13000108)\"}",
				Fault.class);
				
		Mockito.when(portabilidadeService.solicitaPortabilidade(
			PanMatchers.similar(solicitaPortabilidadeAndamentoRequest),
			eq(portabilidadePropeties.getHeader())))
			.thenThrow(new AutbankException("Solicitação de Portabilidade já cadastrada.(13000108)", solicitaPortabilidadeAndamentoFault));
		
		
		SolicitaPortabilidade solicitaPortabilidadeSucessoEncontrado = objectMapper.readValue(
			"{\"codBancoOrigem\":\"0033\",\"cnpjEmprdr\":\"33412792000160\",\"denSocEmprdr\":\"CONSTRUTORA QUEIROZ GALVAO S.A.\",\"codColigada\":\"001\",\"codAgencia\":\"00019\",\"nroConta\":\"1000091545\",\"cpfCliente\":\"17464609115\",\"sisOrigem\":\"DBAPP\"}",
			SolicitaPortabilidade.class);	
		
		Mockito.when(portabilidadeService.solicitaPortabilidade(
			PanMatchers.similar(solicitaPortabilidadeSucessoEncontrado),
			eq(portabilidadePropeties.getHeader())))
			.thenReturn("59285411999900000038");		
	}

	@Test
	public void errorAccessManager() {
		given().port(port)
			.header("Content-Type", "application/json")
			.header("Accept", "application/json")
			.header("origem", "REST-assured")
			.post("/portabilidade")
			.then()
			.statusCode(400)
			.body(
				"results.developerMessage", containsString("APPLICATION-ID"),
				"results.developerMessage", containsString("API-KEY"));
	}

	@Test
	public void portabilidadeEmAndamento() {
		given().port(port)
			.header("Content-Type", "application/json")
			.header("Accept", "application/json")
			.header("API-KEY", "n6AosBCdUfy13ul7Vg4fYZVWxbXhuyVP")
			.header("APPLICATION-ID", "bancodigital")
			.header("origem", "rest-assured")
			.body("{\"banco\":\"0341\",\"documentoEmpregador\":\"64595202000106\",\"razaoSocial\":\"EMPREENDIMENTO RRRR SA\",\"documento\":\"21887127062\",\"agencia\":\"0001\",\"conta\":\"009256845\",\"digito\":\"0\"}")
			.post("/portabilidade")
			.then()
			.statusCode(422)
			.body("results.code", is("PORT009"));
	}

	@Test
	public void solicitadoComSucesso() {
		given().port(port)
			.header("Content-Type", "application/json")
			.header("Accept", "application/json")
			.header("API-KEY", "n6AosBCdUfy13ul7Vg4fYZVWxbXhuyVP")
			.header("APPLICATION-ID", "bancodigital")
			.header("origem", "rest-assured")
			.body("{\"banco\":\"0033\",\"documentoEmpregador\":\"33412792000160\",\"razaoSocial\":\"CONSTRUTORA QUEIROZ GALVAO S.A.\",\"documento\":\"17464609115\",\"agencia\":\"0001\",\"conta\":\"100009154\",\"digito\":\"5\"}")
			.post("/portabilidade")
			.then()
			.statusCode(201)
			.body("results.protocolo", is("59285411999900000038"));
	}
	
	@Test
	public void documentoEmpregadorInvalido() {
		given().port(port)
			.header("Content-Type", "application/json")
			.header("Accept", "application/json")
			.header("API-KEY", "n6AosBCdUfy13ul7Vg4fYZVWxbXhuyVP")
			.header("APPLICATION-ID", "bancodigital")
			.header("origem", "rest-assured")
			.body("{\"banco\":\"0033\",\"documentoEmpregador\":\"33412792000199\",\"razaoSocial\":\"CONSTRUTORA QUEIROZ GALVAO S.A.\",\"documento\":\"17464609115\",\"agencia\":\"0001\",\"conta\":\"100009154\",\"digito\":\"5\"}")
			.post("/portabilidade")
			.then()
			.statusCode(400);
	}	
}
