﻿create table "TCPCONF_DEV"."SISTEMA_MENSAGEM"
(
    "ID_SISTEMA_MENSAGEM" number(10, 0) not null, 
    "DESCRICAO" nvarchar2(1000) not null, 
    "EXCLUIDO" number(1, 0) not null, 
    "DATA_INCLUSAO" date not null, 
    "DATA_ALTERACAO" date not null,
    constraint "PK_SISTEMA_MENSAGEM" primary key ("ID_SISTEMA_MENSAGEM")
)
/

GRANT SELECT, INSERT, UPDATE ON TCPCONF_DEV.SISTEMA_MENSAGEM TO TCPAPI_DEV
/

alter table "TCPCONF_DEV"."MENSAGEM" add ("ID_SISTEMA_MENSAGEM" number(10, 0) not null)
/

INSERT INTO TCPCONF_DEV.SISTEMA_MENSAGEM (ID_SISTEMA_MENSAGEM, DESCRICAO, EXCLUIDO, DATA_INCLUSAO, DATA_ALTERACAO) VALUES (1, 'Front-End', 0, SYSDATE, SYSDATE)
/

INSERT INTO TCPCONF_DEV.SISTEMA_MENSAGEM (ID_SISTEMA_MENSAGEM, DESCRICAO, EXCLUIDO, DATA_INCLUSAO, DATA_ALTERACAO) VALUES (2, 'Back-End', 0, SYSDATE, SYSDATE)
/

alter table "TCPCONF_DEV"."MENSAGEM" add constraint "FK_CONF_MENSAGEM_ID__172173813" foreign key ("ID_SISTEMA_MENSAGEM") references "TCPCONF_DEV"."SISTEMA_MENSAGEM" ("ID_SISTEMA_MENSAGEM")
/

declare
model_blob blob;
begin
dbms_lob.createtemporary(model_blob, true);
dbms_lob.append(model_blob, to_blob(cast('1F8B0800000000000400ED5DC98EE3B819BE07C83B183EE410D4946B490349A56A061A5BEED6A4BCC0B21B9D93C1B2592E6564C9D1D2A942304F934380BC420E39CC03E51542ED222952A416DB3511FA506D89FCF8F3E7BFE9E7F6DF7FFFE7FEBBD7BDD9FB0A1DD7B0AD87FEF5E555BF07AD8DBD35ACDD43DFF79EBFF97DFFBB6F7FFDAB7B75BB7FED7D4ECADD06E5504DCB7DE8BF78DEE16E3070372F700FDCCBBDB1716CD77EF62E37F67E00B6F6E0E6EAEA0F83EBEB0144107D84D5EBDD2F7CCB33F630FC817E0E6D6B030F9E0FCC89BD85A61B3F476FF410B537057BE81EC0063EF4979B032AFE6CEC7C076C807DA959CF0E80AEE7F81E7A723931760EF010916EBFA798064004EAD07CEEF78065D95EF8E66EE542DD736C6BA71FD003602EDF0E10957B06A60BE36EDD65C5457B787513F47090554CA036BEEBD97B49C0EBDB986503B27A25C6F7539622A6AA88F9DE5BD0EB90B10FFD3970D05FC4927E8F6CED6E683A41499AF1D1505DA675B3FF5DF488B217A9E420010BFE5DF486BE89C60B3E58D0F71C605EF4E6FE93696CFE04DF96F68FD07AB07CD3CC138DC846EFB007E8D1DCB10FD0F1DE16F039EE8AB6EDF70678BD015931AD96AB13F551B3BCDB9B7E6F8A1A074F264C6522C70FDDB31DF8115A108919DCCE81E741C70A3060C855AA75A22DC435DFB493F690182245EBF726E0F5115A3BEF05A9E01552ADB1F10AB7C9939886956520BD449590A8C3021AF9ED0E5FC05778FC663F03D3761A6896DFCA087840B336A6EF8294B5E8195C221B234D7200A698685403C9AD8DA66D57AE0F1CC326E963899A201C4561353CF51551656C5394EF6DDB84C02AC1B91F6426846B5826D072C10EEEB5AD818C4A05EB92005CE2489D8561B7B5343CBE85B9F9F0A10D551F4177E31839892C68FAC3F54D1B4D2B7FF1B780D32CFA6F1BCD26521DB78BC28CCBE451059BD319B0E319308433055F8D5DA870A4878E2D4DBFB78066144ABE1887787C7133B4CECA8E1D7BBFB04DCAE6A545D6BAED3B9BC005DBFC724BE0ECA057D3E036616A3B23CB6E4B375C0F12BA1F3FCB86403656828EF18C0C680561960D325B328843F4DDB83B41BB73073E1BAF2768B8B3DBE763B73F3AFEC1E61AED755C84B6D5D11BA6898E5F175966014F12A4229A7525092165AE24E94F255712F6B9097F8201754E85DDD6D4F80A4DCCA5844F2A3B94A571B031B8E0416534E5E0401775043843B0A9EBA132B04FD03CD4452BF53B1F5A496E74D6FF4CD30E8A055FEDA9ED85E11422B6861553F7C0302F59809D35E3286549C6F1B6952CC410EC0DEBE5043988CE189C4F2898D3D4C2D0AB4093D78FE8EB0D847AEEE643B092A254285656BE5648D6A449EBAC996456B52096C2E44C3E5DEA1916D273A448EEF1BF5C15D7F52DEF0469E24C708F9E25805630D8B06EB4' as long raw)));
dbms_lob.append(model_blob, to_blob(cast('A9FB1BE8BAB593340BE8225DCA657B6AF8AA1283ED7EF2F6665D7A3B07773E0E0E7356ED3A38322722EA102B393822853A3176137038845A513DFFA05AFEDE25B3B31934E5F5C400C2A7D96A93CC555EFD525DE5D4B61A9904BCBE6A67AD4165353B5743271E17E6D3444D2A0D03585465B0EA9DC2740A732E0A1325CA9BD41412515445A27A9D6E74BA712EBA919F246852438A7145F5245FBBD3964E5BCE495BF29F447514264ACC65F25E88CB54184EED4E613A853999C2F87B2AF0EAF734776C825DB6E9A299F0ABB104361ADD2D74CC37240E7949C4B93781FB27E8241D43159E0D2B1CD2CFC0F4D1A32B8ADF588DB9ED78FECE876E5AE19A5F41B37666AEF40DBFB4EA1E80F5629B69F95B7AC0A2A1E10C17B5A4ADE971231A78570338766CCB53ADADE8F87D0F363FE68BDF541810624148D3C381C1BFABC1501DC7161D08C544460F882A92663DDB2C2522CBA6530371F1DF5518627C914ED3239C477F5703FC03B0A0094487189B99ABA16FD42C5FEDF1E08469EF6A3CC27E880E87BE67FAADE2615090166D8C90A3C4BC61BC88136F0C99D51E7F456736719BE9D604F1D23820EEA1B8E5A1FF5BAA0B4CD474D23F4325564BE2D0D738B9087A668DA0093DD85336D196D0217037604B8768883B5B8C5B39CE88318C5C5F5AD647E6BE059A85493427CF48E68AD6F2713A0933CB26D458FD159E5DCBADF92C5AE441B280CD61E1052B598BECE572DC8165B22FFA124086CC038695DA00C2B605AFE1AB576041572E8C8DA81B7F5D917D0DE075E8258174B2EF38088EB3AF90B873B9BDCD14CF701C5C368BB048B91704E44195826086A50889B03C2570ACB12E4266CB45492382F855A099D3B8450D70A693CB7A503CF155D80BD6E45B4913E48C4111363D4F51025A9C642D8266A579051A28CC4BB1DA6024C78866729684D69F64DF46AE50F1CE0ED23194860569EF30651D08E324C6348743EA2BE982F09E4A7081DA27C26607D7E54B39FD0206A5E651804D2C372FC2F70AAC2A5DF642B34CCAB15772EDB9BE16DB450E1F459D79AE0D8E8117E66F92CC4B5D78FAEE7E109DC8123FB81F308E6EB94FAC4256337ED2D3A3735C86DFE8F22799EC238CC1C62D38D024A5366DC9B31DD475E26DB85D048E0DC7F58284E713083EE386DB3D558C11B030EC63D2281D93D0C39B98C9A44EF0FFC220897DBA4D2EAE21F033568F51EFF7D0F24246C09C8C70EAF682337780099C82A4FCD036FDBD15FF1EADE7CA4299A8CBC56C3D9C4DC7DAC7D542192A335A9ED9A0C93ED53CF064365A3D4AA1C41B0DF220C34FCA675506233EA7248FF159799C2D6430F05C7C1E6AA42C95B5361D3EAE7439061119790A53795CAAD25C2F582D498CEC4A5F290B6D5689E4A2C5930CF84AD46733277954F50BA2541B1522DD0F087D201572406924F5D9882BB990' as long raw)));
dbms_lob.append(model_blob, to_blob(cast('0920FD653B6680F82491B7056500120661A24E75E5A33A596B236D365164463539B4248FB8D49692962037A387A98AAA0F179AA49CC5678AE471941F5623A95E25DF89389F6479D3D995CEAE14D895B62D4A0D5BD288159119BCF4380E024BD7F4A53A512A61E68FE3C0E20275A18D913529168A96439D78A33316EBCC46DA472994F4B88C3CCC7CA18EB52FD256A4334C9D612ACE54B6639DF06CA7BC892AA92F61A73E2E56F35925CB129FF340E04DB5CFEA6325BC686F2201B7D42A52479CF3800540C848E8EA74A92CD64365580D343AEF8181FA497D9C1FDF1E7676ACB363393BC6CEA0B563D298D32CF2D64D1C4AC2D02953F5CB6C3D9D2DC3B0078D7A25B3D24496263DDC01435126DAF453A7F09DC25755F823EA7A336ADEB486E774BB5EDC11041D92099BFC210844D266A94D91EA20F9D3A5428DE464032CC6D0F5D57429F7C5964EB461DF6C154C5F76F000F6C1A54E4728EA913280E9FAC23C90BE1AAABA2ED5B7DCD90379241487AD1E97925FB6C9E902984CE9EB4FCBC96367933B9B5CD12673D679B46399D96B45E4EDB304968495AE93CC6A32332E2F43EF45E74F157FB0161BB5148330162C5588434491646291CA69904EC6CF58C6E9D56EED0837B5624E5EAACB2124C4B9C2745F27C6E72BC6ACF595ED0833638DA6BC488B02490876E5FC7227DF672EDF8CE5BDED8978F112E16A522E88252BE81533249DAC9F83ACE3EB5C8B5753246BCCEBAC984830449745040B7D1949277C7D39CDB1A62629C32D51098C3479F112E7EAE455218C5CB75C79C8A905F5F5D7DFE5C0E4D6D97178CD58437F5CA64B51D8985830A3E716A5A3740F4143697F1CB4EA445EC1A808EE4BA83E3A5C5F282942821B1CAA132B33795947AAA82D136491D4C9C54FD2DFE9968978BB42F915B8D4FE85A848BF8768FF6A6C83BD0B33249126BC9C000B216E43EFBC09A60E2E87A6811C6C561495309E91CC46BBC7FBD7D79737C4C5B9E77389EDC075B7D829447237D97E5C28D3E57AA4C6132F3A928FA9AE2E9617AB398A51D48B91FAA8A23F0B75AC2ED4E950D50B30466F1640348E8D20D659A7ADAD93E00C05642149E3E0C5DF6CE7C74BAC868BFF1C857BEE437EE0E22676B692E8160C812397D850D1763ECB0F76F307620337467C57F415325B480B61785440E9F1EAB2C784C76B23E3E6BF0267F3029C1BFAF258D9FB21A235074DC3C69B45246085EEB5C5C3F1087D0BBC0A473B1141780DA8C2192E4129A9DE14457BD36D651F526C7C61F8E62EC86DDE681151DB892C5749882764B2288C13D9AA64A30A4FFBC3DB146495364B13F0A0C34B0264AF7F88B6B2C4B01BD37EAAA09C454CA7844F9DAE26EBE59FE7AADC516ECD29766744DFA911E5EA7CA9DC05271ABD3EF4FF1E56BDEB695FD6B9DA17BD998382DFBBDE55EFA7AABD6FE24EDEF6' as long raw)));
dbms_lob.append(model_blob, to_blob(cast('ACFBA9ED7A2D837E324B5EB8CAA26903471DAAD894F6E57726B5A27F44505EC96D24CBF3EB60A47B95EA80747EE197E417C8447715EF80631CD547945DB6DBBCA3C05A3C95B7E04F4F08F90CFEC01FD373902B979AF61BC4D9AF0DDA01622EBF69C2F1134D9BA29BDC8CD68A65A1F6A6B5D20AE1138BBFF2BA2F9FFF1B0FD7C645C7CD7B1056E3A77226E2533D428E85077722272390BCBE954F33A51BE89A4E3275F6E79DDA9FE2F0263FED5B25BCCE011C35B63E957D3C23D3C899B217B2859CB13F62967D5E2E78E5B129E7FCF50673CEF8E6C53A698A74E762D3B30B9437AB968A497731B66277D2BD8DADA0E7F63B4AF83EA12B97930D90ADD0DD39D677EA585BB90839B4792375AC4DB5A5369B22B7FB9BBFFAB6F7C7E45E85E8D75DF4A7528A3AAA7A112304BD0BA8C470C9B4395645DB66ABB2B05A05F976AC627865841B5789BB758D218497F07CA35A5BACDE0D5626B878272BF2D34F159D68D9FE4B214F5A36BDD0A00712993B8EEE373BAF58F30CAC5B0B372FB7A0A558E3023A8A272885359453AD5C3F837B9938AA195DC58415B8C5DBB79EF1FABFC3CD4E7420424DCDE6EF39158B90B9C9DF4EABDF95560B5C0FDD823A47AD0AE871B4F246587F0B8A97EB6D7C3BE1CFFF7239DA1BDC484896C0D537B985B0A682D6582426B936AC53C8735448E13BA95B50CB7CDB02CA89CDA509EB28BB56B9AA4637E371D4344971FCFCCF9FFF51D75572B7FD0A292477B2B1D3CB77A797A2B75F37A19A9CE49DA86AE6529972DAC9AA281003075473F4539FE84D6865DD242F0DD2E9E6FBD1CDCA3766124B8F22428E79A725464D21212C1AE89B269156402798600026B21FAEE70083DE4E3E770C6B631C8059C801A274B5A54B412FD366C8372378884E0424FBDC58D3690B04E3CBD87384EB458F7CC767210DC91683024A44AF34AD2468B203DDA874316F88916EFA08D2D5E07DAB4D5EAECA5E6F936BA3E275AA55854AEC4859D9696129119338C1BA0A1D8DCB1BB1553B5907435D0B478A01E3DE59FEADB3D1E66C142B0FE7C1CE5A242A916F0F7E886EE0259B26AD15D53E59804B44D95E3C56EBDC6B6D855A2C6D8A0841A8F688F7DC464B161B934DB3D598A2825D944B90C48235923831BAE449AA440C67B292228953964B58E9E41BC521D6CC0CCD2556493EA7F873062439744A99A2832EC22540505959A933AA7956412E11FC7450112D8C744121398CB2E514F13E85DBBE6AB8D06415DC3D433BBAA260B9E818292AE43DCF3B858588E7C6E7ECE393EAB3E0D47705975D0CCC6554996FE29F2124CE3C898B80E9D36B5080E6A3DAFB284D818246D7D86510F708D3821B2C344BCB04B3BE49A448509414A1CEA2F2C03638E6C641FD051B0FBD0E6686437B1166E81EFAEAFE096E356BE67B07DF435D86FB27F32DCF8C20D2E4B51FDE76' as long raw)));
dbms_lob.append(model_blob, to_blob(cast('8CD37C3F3B84273C35D10544A611248066D6F7BE616E53BAC7054920064410C2C64B2E83B1F482A597BBB714696A5B824031FBD2C87B09F7071381B9334B0FEF7191A76DE5C247B8039BB7E4E8213648F940E06CBF1F196087026E37C6C8EAA39F4886B7FBD76FFF07463FDCFAEDC00000' as long raw)));
insert into "TCPCONF_DEV"."CONF_MIGRATION_HISTORY"("MIGRATION_ID", "ContextKey", "Model", "ProductVersion")
values ('201612131013391_1.2.1', 'TcpConfiguracao.Migrations.Configuration', model_blob, '6.1.3-40302');
end;
