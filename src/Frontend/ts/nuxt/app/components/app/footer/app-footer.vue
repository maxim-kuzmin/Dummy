<script setup lang="ts">
  import { useAppFooterComponentStore } from '~/utils/domain/app/components/footer/store/app-footer-component-store.composable'
  import { useAppFooterComponent } from '~/utils/domain/app/components/footer/app-footer-component.composable'

  useAppFooterComponent()

  const { title } = useAppFooterComponentStore()
</script>

<template>
  <footer class="app-footer">{{ title }}</footer>
</template>
