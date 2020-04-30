import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { PersonaConsultaComponent } from './Pulsacion/persona-consulta/persona-consulta.component';
import { PersonaRegistroComponent } from './Pulsacion/persona-registro/persona-registro.component';
import { AppRoutingModule } from './app-routing.module';

import { UsuarioConsultaComponent } from './syscsc/usuario-consulta/usuario-consulta.component';
import { UsuarioRegistroComponent } from './syscsc/usuario-registro/usuario-registro.component';
import { ProductorConsultaComponent } from './syscsc/productor-consulta/productor-consulta.component';
import { FormatoAuditoriaConsultaComponent } from './syscsc/formato-auditoria-consulta/formato-auditoria-consulta.component';
import { MateriaPrimaConsultaComponent } from './syscsc/materia-prima-consulta/materia-prima-consulta.component';
import { FichaDiagnosticoConsultaComponent } from './syscsc/ficha-diagnostico-consulta/ficha-diagnostico-consulta.component';
import { FichaAuditoriaRegistroComponent } from './syscsc/ficha-auditoria-registro/ficha-auditoria-registro.component';


import { UsuarioService } from './services/usuario.service';
import { PersonaService } from './services/persona.service';
import { FiltroUsuarioPipe } from './pipe/filtro-usuario.pipe';
import { ProductorDetalleComponent } from './syscsc/productor-detalle/productor-detalle.component';
import { ProductorDatosFamiliaComponent } from './syscsc/productor-datos-familia/productor-datos-familia.component';
import { ProductorAgroclimaticaComponent } from './syscsc/productor-agroclimatica/productor-agroclimatica.component';
import { ProductorFertilizacionNutricionComponent } from './syscsc/productor-fertilizacion-nutricion/productor-fertilizacion-nutricion.component';
import { ProductorProducccionPecuariaAgricolaComponent } from './syscsc/productor-producccion-pecuaria-agricola/productor-producccion-pecuaria-agricola.component';
import { NavMenuProductorComponent } from './syscsc/nav-menu-productor/nav-menu-productor.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    PersonaConsultaComponent,
    PersonaRegistroComponent,
    UsuarioConsultaComponent,
    UsuarioRegistroComponent,
    ProductorConsultaComponent,
    FormatoAuditoriaConsultaComponent,
    MateriaPrimaConsultaComponent,
    FichaDiagnosticoConsultaComponent,
    FichaAuditoriaRegistroComponent,
    FiltroUsuarioPipe,
    ProductorDetalleComponent,
    ProductorDatosFamiliaComponent,
    ProductorAgroclimaticaComponent,
    ProductorFertilizacionNutricionComponent,
    ProductorProducccionPecuariaAgricolaComponent,
    NavMenuProductorComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ]),
    AppRoutingModule
  ],
  providers: [PersonaService, UsuarioService],
  bootstrap: [AppComponent]
})
export class AppModule { }
