<template>
  <div id="app">
    <b-navbar toggleable="lg" type="dark" variant="info">
      <b-navbar-brand href="#">ProductSeacher</b-navbar-brand>
      <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>
      <b-collapse id="nav-collapse" is-nav>
        <b-navbar-nav>
          <b-nav-item-dropdown text="Web" right>
            <b-dropdown-item>Todas</b-dropdown-item>
            <b-dropdown-item @click="getMercadoLivre('MercadoLivre')"
              >Mercado Livre</b-dropdown-item
            >
            <b-dropdown-item @click="getBuscape('Buscape')"
              >Buscapé</b-dropdown-item
            >
          </b-nav-item-dropdown>

          <b-nav-item-dropdown text="Categorias" right>
            <b-dropdown-item @click="getProducts('Geladeira')"
              >Geladeira</b-dropdown-item
            >
            <b-dropdown-item @click="getProducts('TV')">TV</b-dropdown-item>
            <b-dropdown-item @click="getProducts('Celular')"
              >Celular</b-dropdown-item
            >
          </b-nav-item-dropdown>
        </b-navbar-nav>

        <!-- Right aligned nav items -->
        <b-navbar-nav class="ml-auto">
          <b-nav-form>
            <b-form-input
              v-model="searchTerm"
              type="search"
              size="sm"
              class="mr-sm-2"
              placeholder="Search"
            ></b-form-input>
            <b-button @click="searchProducts" size="sm" class="my-2 my-sm-0"
              >Search</b-button
            >
          </b-nav-form>
        </b-navbar-nav>
      </b-collapse>
    </b-navbar>
    <Products ref="products" />
  </div>
</template>

<style lang="scss"></style>

<script>
import Products from "./components/Products.vue";
import { bus } from "./main";

export default {
  components: {
    Products,
  },

  data() {
    return {
      searchTerm: "",
      plataforma: "",
    };
  },

  methods: {
    getMercadoLivre() {
      this.plataforma = `MercadoLivre`;
    },

    getBuscape() {
      this.plataforma = `Buscape`;
    },

    getProducts(category) {
      bus.$emit("loadProducts", { category, plataforma: this.plataforma });
    },

    searchProducts() {
      bus.$emit("searchTerm", this.searchTerm);
    },
  },

  watch: {
    searchTerm: function (val) {
      if (!val) this.searchProducts();
    },
  },
};
</script>
