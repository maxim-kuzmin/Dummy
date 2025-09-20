<script setup lang="ts">
  import { useAppFooterComponent } from '~/utils/domain/app/components/footer/app-footer-component.composable'

  const { title } = useAppFooterComponent()
</script>

<template>
  <footer class="app-footer">{{ title }}</footer>
</template>
